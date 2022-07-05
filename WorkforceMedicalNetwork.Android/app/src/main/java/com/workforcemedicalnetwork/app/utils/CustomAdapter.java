package com.workforcemedicalnetwork.app.utils;

import android.net.Uri;
import android.view.View;
import java.util.ArrayList;
import android.view.ViewGroup;
import android.content.Intent;
import android.widget.ImageView;
import android.widget.TextView;
import android.content.Context;
import android.widget.ListAdapter;
import android.view.LayoutInflater;
import android.database.DataSetObserver;
import com.workforcemedicalnetwork.app.R;
import com.workforcemedicalnetwork.app.Constants;
import com.workforcemedicalnetwork.app.models.ImageData;
import com.workforcemedicalnetwork.app.ui.BrowserActivity;

public class CustomAdapter implements ListAdapter {
    ArrayList<ImageData> arrayList;
    Context context;
    public CustomAdapter(Context context, ArrayList<ImageData> arrayList) {
        this.arrayList=arrayList;
        this.context=context;
    }

    @Override
    public boolean areAllItemsEnabled() {
        return false;
    }

    @Override
    public boolean isEnabled(int position) {
        return true;
    }

    @Override
    public void registerDataSetObserver(DataSetObserver observer) {
    }

    @Override
    public void unregisterDataSetObserver(DataSetObserver observer) {
    }

    @Override
    public int getCount() {
        return arrayList.size();
    }

    @Override
    public Object getItem(int position) {
        return position;
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public boolean hasStableIds() {
        return false;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        final ImageData subjectData = arrayList.get(position);

        if(convertView == null) {
            LayoutInflater layoutInflater = LayoutInflater.from(context);
            convertView = layoutInflater.inflate(R.layout.image_listview, null);
            convertView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    String url = subjectData.Link;
                    openWebPage(url);
                }
            });
            TextView title = convertView.findViewById(R.id.title);
            ImageView image = convertView.findViewById(R.id.image);

            title.setText(subjectData.Title);
            image.setImageResource(context.getResources().getIdentifier(subjectData.Image, "drawable", context.getPackageName()));
        }
        return convertView;
    }

    public void openWebPage(String url) {
        if(Constants.UseInternalBrowser) {
            Intent intent = new Intent(context, BrowserActivity.class);
            intent.putExtra("url", url);
            context.startActivity(intent);
        } else {
            Uri webpage = Uri.parse(url);
            Intent intent = new Intent(Intent.ACTION_VIEW, webpage);
            context.startActivity(intent);
        }
    }

    @Override
    public int getItemViewType(int position) {
        return position;
    }

    @Override
    public int getViewTypeCount() {
        return arrayList.size();
    }

    @Override
    public boolean isEmpty() {
        return false;
    }
}